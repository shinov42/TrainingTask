This project represents a simple automation framework for both API and UI tests. 

In this task you'll need to fix/adjust three existing auto tests and make sure that they work properly. 
Test cases that you'll need to follow are:

1 - Pet Store
See https://petstore.swagger.io/ for documentation
|  ##            | Step Description                                                | Expected Result                               |
|:--------------|:---------------------------------------------------------------|:---------------------------------------------|
| Precondition   | Create a pet using get request                                  |                                               |
| 1              | Get a pet by ID (using one from precondition)                   | Pet is added with the specified name          |
| 2              | Update a pet from previous step and change the name to a new one| Request was successful & the name is updated  |
| Post-condition | Delete a pet from a pet store                                   |                                               |

2 - Dynamic Controls
|   ##           | Step Description                                                | Expected Result                               |
|:--------------|:---------------------------------------------------------------|:---------------------------------------------|
| Precondition   | Open main page by URL https://the-internet.herokuapp.com/       |                                               |
| 1              | Click "Dynamic Controls" link on the Main page                  |                                               |
| 2              | Click "Enable" button                                           | Enable/disable input is enabled               |
| 4              | Send random text to Enable/disable input                        | Random text is displayed                      |

3 - IFrame
| ##             | Step Description                                                | Expected Result                                          |
|:--------------|:---------------------------------------------------------------|:--------------------------------------------------------|
| Precondition   | Open main page by URL https://the-internet.herokuapp.com/       |                                                          |
| 1              | Click "Frames" link on the Main page                            |                                                          |
| 2              | Click "iFrame" link on the Frames page                          |                                                          |
| 4              | Input random generated text to the text editor                  | Random text is displayed                                 |
| 5              | Undo changes with Edit menu                                     | "Your content goes here." text is displayed in the editor|