Feature: Iframe
To verify that text can be edited within an iFrame and that the changes can be undone.

@ui
Scenario: Editing Text in an iFrame and Undoing Changes
	When I Click 'Frames' link on the page
	  And I Click 'iFrame' link on the page
	  And I Input random generated text to the text editor and save as '_randomText' 
	Then Random text is displayed in Iframe
	When I Undo changes with Edit menu
	Then Expected text 'initText' is displayed in the editor
