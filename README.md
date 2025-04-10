Important Information to Note
-----
**Please not that "...FinalProject\MauiApp1\bin" and "...FinalProject\MauiApp1\obj" are not uploaded on GitHub because this would be ~700MB of excess. The folders are there, but are empty.**

Project Description
-----
This program was my Final Project for my ITS440 Application Integration from December 2023.

The Album Reviewing Application is a C#.NET MAUI based mobile application program that lets the user enter and modify various pieces of information relating to reviewing an album. It uses SQLite to locally saved user inputted information.

Main Page
-----
<img width="250" alt="image" src="https://github.com/user-attachments/assets/93e9eddc-7e5b-4668-8fbc-5bacb897c3d1">

When opening the application for the first time, the only option you are given is to create a new album entry. 

New Entry Page
-----
<img width="250" alt="image" src="https://github.com/user-attachments/assets/84c6be9d-4b7a-4bbb-93de-4e4d856f33af">
<img width="250" alt="image" src="https://github.com/user-attachments/assets/1e2b8a6b-215e-406b-83f5-854761c9e8c3">

When you click the new album entry button, you will be taken to a new screen (left). This new screen will show you various pieces of information related to the album to fill our, with examples of formatting. This information includes information like artist name, album name, year released, number of songs, date listenied to, rating out of 10, notes, etc..

Different pieces of information require certain types of input data. For example, artist name and album name can be strings; rating out of 10 is a rating between 0.0 and 10.0 in tenth intervals; year released must be a 4-digit number, etc.

The example to the right is an example of information from The Beatles' "Abbey Road" album inputted by the user.

<img width="250" alt="image" src="https://github.com/user-attachments/assets/3d419661-7781-43cb-b7b0-602692ca7043">

Once the user has filled out the information, they will be returned to the main menu, now populated with the newly entered information.

Album Details Page
-----
<img width="250" alt="image" src="https://github.com/user-attachments/assets/13c1e23a-10f0-404d-aa22-411f0b0662cb">

If the user clicks on that newly populated information, a new page will pop up, showing the entered album information.

There will also be two new buttons: one to edit album details and another to delete an album entry.

Edit Details Page
-----
<img width="250" alt="image" src="https://github.com/user-attachments/assets/0e1b6b80-3c8f-4693-8034-d5d8ee8da95c">
<img width="250" alt="image" src="https://github.com/user-attachments/assets/7e4867d2-f8b8-4ac8-961f-fd68fbe036ad">

If you were to choose to edit album details, you'll find a similar page to the one where you originally entered the information. It is colored yellow to distinguish from the normal "Enter New Entry" page. From here you can edit any information you previously added. You can press the "Save Edited Details" button to save your changes.

<img width="250" alt="image" src="https://github.com/user-attachments/assets/f391d8dc-2957-46c0-aebf-c4424cc6b821">

Back in the main screen, you can see the information has updated.

Deleting an Entry
-----
<img width="250" alt="image" src="https://github.com/user-attachments/assets/3ecf7971-d56b-4a90-bf8f-83b6d4de7046">
<img width="250" alt="image" src="https://github.com/user-attachments/assets/dc83bd90-7848-4a94-9c35-103b9719bf98">

Returning back to the details page, if you were to press the "Delete Album Entry" button, you will be prompted again to confirm the deletion of the entry.

Upon confirming the deletion, you can return to the main screen, you'll see the entry has been removed.
