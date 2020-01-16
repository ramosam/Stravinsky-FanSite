# **CS296 Web-Development**

### Lab 1 - Validation

Controller validation occurs in the ForumController, within the RedirectToActionResult AddForumQuestion.



Models that have had validation added:

* ForumQuestion
  * Required
  * UIHint
  * StringLength, MinimumLength
  * StringLength, MinimumLength, ErrorMessage
* Member
  * Required
  * StringLength
* Reply
  * Required
  * StringLength, MinimumLength
  * StringLength, ErrorMessage
* Tutor
  * Required
  * StringLength, MinimumLength



######	Note: Controller validation has not been added explicitly for Member, Reply, or Tutor.  

The intent is that validation for the Member and Tutor models will be implemented later with user authentication and authorization.  Replies are currently submitted to the controller as strings and not as Reply objects.



Jan 10, 2020