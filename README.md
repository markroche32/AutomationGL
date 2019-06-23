# AutomationGL

# Question 1 - Requirements

Story Title :

Login Viewpoint Voting Platform Missing Username/Password

Description :

This Story is to encapsulate the scenarios/functionality of not providing Username/Password
when logging into the Viewpoint Voting Platform


Acceptance Criteria :

AC : 
Given Username and Password are NOT provided and User clicks login 
Then "Viewpoint Voting Platform" message is displayed

AC : 
Given Username IS provided BUT Password IS NOT provided and User clicks login 
Then "Viewpoint Voting Platform" message is displayed

AC : 
Given Password IS provided BUT Username IS NOT provided and User clicks login 
Then "Viewpoint Voting Platform" message is displayed

# Question 2 - Automation


# 1. Test Plan and Integartion Tests :

Test scenario should verify that selecting country and clicking Update, that results are correct on Web Disclosure page for each country and that no other country meeting results appears in updates results lists.

Test scenario should verify that Clicking Company  on Web Disclosure page for
each company navigates to that companys vote card page.


Test scenario should check negative scenarios where Company cannot be found

Integration Tests should include testing the company and country filter with real data, all
combinations of data with the existing existing functionality to ensure all functionality is
working together as expected.



# 2. Automation is on GitHub


# 3. Instruction on how to run tests :

Install Following Libraries via Nu Get Package Manager VS :

OpenQA.Selenium;
SeleniumExtras.PageObjects;

# 4. Based on what you found difficult or easy from the automation exercise
please give some feedback that development team could use to improve the
system under test to make it easier to automate :


Generally a Test Plan is existing, Test Cases have been written, and Test Automation is generated
from those TC - in this task the format was a little confusing as AC and clear scenarios existed
and then a Test Plan was asked to be generated, it seemed a little like working backward.




