// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const USERSTORY_URL = "https://localhost:44359/api/APIUserStories";
// const USERSTORY_URL = "https://stravinsky19.azurewebsites.net/api/APIUserStories";

/***********************************************************/
/************* Get all UserStories from the API ************/
/***********************************************************/

// This function is called by other functions that pass in the onloadHander
function getAllUserStories(onloadHandler) {
    var xhr = new XMLHttpRequest();
    xhr.onload = onloadHandler;
    xhr.onerror = errorHandler;
    xhr.open("GET", USERSTORY_URL, true);
    xhr.send();
}

// Loop through the storys and put them in the table
function fillTable() {
    var stories = JSON.parse(this.responseText);
    for (var i in stories) {
        addRow(stories[i]);
    }
}

// Put info for one story in a table row
function addRow(story) {
    var tbody = document.getElementsByTagName('tbody')[0];
    var fields = ["storyPost", "name"];
    var tr = document.createElement('tr');
    // Add a cell with the value from each field
    for (var i in fields) {
        var td = document.createElement('td');
        var field = fields[i];
        if (field == "storyPost") {
            td.innerHTML = story[field];
        } else if (field == "name") {
            td.innerHTML = story[field];
        } 
        tr.appendChild(td);
    }
    tbody.appendChild(tr);
}

function errorHandler(e) {
    window.alert("UserStory API request failed.");
}

/***********************************************************/
/**************** Add a story to the database **************/
/***********************************************************/

// Generate a story object from the HTML form data
function getFormData() {
    // collect the form data by iterating over the input elements
    var data = {};
    var form = document.getElementById('storyForm');
    for (var i = 0; i < form.length; ++i) {
        var input = form[i];
        // if the form field has a name, add the name and value to the data object
        if (input.name) {
            data[input.name] = input.value;
        }
    }
    return data;
}

// Send a new story object to the database
function addStory() {
    var data = getFormData();
    // create an HTTP POST request
    var xhr = new XMLHttpRequest();
    // Parameters: request type, URL, async (if false, send does not return until a response is recieved)
    xhr.open("POST", USERSTORY_URL, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;
    xhr.onreadystatechange = function () {
        // if readyState is "done" and status is "success"
        if (xhr.readyState == 4 && xhr.status == 200) {
            addRow(JSON.parse(xhr.responseText));
        }
    };
    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(data);
    xhr.send(dataString);
}

/***********************************************************/
/********* Update a story already in the database **********/
/***********************************************************/

// Fill the select (drop down list) with story titles
// Called by getAllStories which is called by the page load event
function fillSelectList() {
    var storys = JSON.parse(this.responseText);
    var sel = document.getElementsByTagName('select')[0];
    for (var i in storys) {
        var opt = document.createElement("option");
        opt.setAttribute("value", storys[i].userStoryID);
        opt.innerHTML = storys[i].storyPost;
        sel.appendChild(opt);
    }
}

function clearSelectList() {
    var select = document.getElementsByTagName("select")[0];
    var length = select.options.length;
    // remove all but the first option element
    for (i = 1; i < length; i++) {
        select.options[i] = null;
    }
}

// get one move by it's ID
// onloadHandler will be fillForm()
// Called when a story is selected from the select list
function getStoryById(event) {
    var xhr = new XMLHttpRequest();
    xhr.onload = fillForm;
    xhr.onerror = errorHandler;
    xhr.open("GET", USERSTORY_URL + "/" + event.target.value, true);
    xhr.send();
}

// puts data from existing story into the form 
// called back by getStoryById
function fillForm() {
    var story = JSON.parse(this.responseText);
    var inputs = document.getElementsByTagName("input");
    inputs[0].value = story.userStoryID;
    inputs[1].value = story.storyPost;
    inputs[2].value = story.name


}

// Send new data for an existing story to the database
function updateStory() {
    var form = document.getElementById('storyForm');
    var userStoryID = form["userStoryID"].value;

    var newPatchCommand = userStoryID + "?&operation=replace" + "&parameterName=storyPost"
        + "&parameterValue=" + form["storyPost"].value; 

    // create an HTTP PATCH request
    var xhr = new XMLHttpRequest();

    xhr.open("PATCH", USERSTORY_URL + "/" + newPatchCommand, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;

    xhr.send();
    clearSelectList();
}

// Send new data for an existing story to the database
function replaceStory() {

    var data = getFormData();
    // create an HTTP POST request
    var xhr = new XMLHttpRequest();
    // Parameters: request type, URL, async (if false, send does not return until a response is recieved)
    xhr.open("PUT", USERSTORY_URL + "/", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;

    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(data);
    xhr.send(dataString);



}

/**************************************************/
/******************** Delete a story **************/
/**************************************************/

// Remove a story from the database
function deleteStory() {
    var data = getFormData();
    var xhr = new XMLHttpRequest();
    xhr.open("DELETE", USERSTORY_URL + "/" + data.userStoryID, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;
    xhr.onreadystatechange = function () {
        // if readyState is "done" and status is "success"
        if (xhr.readyState == XMLHttpRequest.DONE && xhr.status == 204) {
            clearSelectList();
            getAllStories(fillSelectList);
        }
    };
    xhr.send();
}