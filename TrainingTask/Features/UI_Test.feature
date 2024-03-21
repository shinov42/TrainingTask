Feature: UI test

Automation training with Welcome to the-internet application


@TestCaseId_01
Scenario: Dynamic Controls
Given I launch the app url
When I click Dynamic Controls link on the Main page
And  I Click Enable button
Then Verify that the Enable/disable input field is enabled
When I send random text to Enable/disable input field
Then  Random text is displayed

@TestCaseId_02
Scenario: IFrame
When  I click Frames link on the Main page
And I click iFrame link on the Frames page
And  I Input random generated text to the text editor
Then Random text is displayed
When I click on the edit button
And I click on the Undo Button
Then Your content goes here text is displayed in the editor