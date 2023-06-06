# Car Sales Manager

![](https://lh3.googleusercontent.com/pw/AJFCJaV45nazQzs4oCB8RMNudEY4RlUYUdKIjE3vMS11itYDiOTJEW8IsNync62wnjSU5vRx-eQrduPCFSwooit4_g-gPfKBvsssDIy94IzFjJXGkKR9CRQsSNrCtiuhkqyTMSPW3FOKlafTkar3OxecCkT1=w958-h508-s-no)

## ✏️ Overview
This practice project is a mock WPF customer management application built using C# and XAML. It allows users to perform basic calculations, manage customer records and perform various operations such as searching for customers, deleting customers, and managing vehicle makes. 
The app utilises event handlers to handle button clicks and incorporates error handling and input validation to catch and display any errors that may occur during input parsing or validation. It provides a user-friendly interface for inputting vehicle and customer details, calculating costs, and generating a brief summary.

## 🔧 How It Works

### 📊 Summary button
The app uses C# code to handle user interactions and perform calculations. Here's a brief overview of the key steps when clicking the "Summary" button:

1. User inputs the vehicle price and trade-in value.
2. The app validates the inputs, ensuring that the vehicle price is greater than 0 and the trade-in value is greater than or equal to 0.
3. If the inputs are valid, the app proceeds to calculate the sub-amount, GST amount, and final amount based on the provided values, including the calculation of warranty cost, optional extras cost, and insurance cost.
4. The calculated amounts, along with other customer details, are displayed in the summary text box.

## 🚀 Features

### Displaying All Customers
This button displays a summary of all saved customers' names and phone numbers.

### Search for Customers

The app provides a search functionality to find customers by name. If the name is found, the corresponding phone number will fill the phone number text box. Otherwise, an error message is shown.

### Delete Customer

Users can delete a customer from the records by entering the customer's name. The app performs a search for the name and if found, removes the customer from the list of names and phone numbers.

### Display All Vehicle Makes

This feature allows users to view all the available vehicle makes in the application. It retrieves the list of vehicle makes and displays them in alphabetical order in the summary details.

### Search for Vehicle Makes

Users can search for a specific vehicle make using the binary search algorithm. The app performs a binary search on the sorted list of vehicle makes and displays a message indicating whether the make was found or not.

### Insert Vehicle Make

Users can add a new vehicle make to the list. The app first checks if the make already exists using the binary search algorithm. If not found, the make is added to the list, and the list is sorted again.

## 🛠️ Built With
This project was built using the following technologies:

- Visual Studio: Integrated development environment (IDE) used for coding and project management.
- C#: Programming language used for app development.
- WPF (Windows Presentation Foundation): Framework used for building the user interface and handling user interactions.
- XAML (eXtensible Application Markup Language): Markup language used to define the UI layout and design.

## 📷 Screenshots

### Input Validation
![](https://lh3.googleusercontent.com/pw/AJFCJaXxY3MzHez27QkczN_CN1iVCpbhP7g4qfWkczdirsKxIVgrOvqi_TdRL8ityf9cJvhwNNlt9kiJQlTyuGqb6A-4DzEZjS2B0EnoTv2gWlGxq5Hz_V-wjv6p-2felJmG1fwLYoLENRPTk5jU-6xsuq9F=w958-h511-s-no)

![](https://lh3.googleusercontent.com/pw/AJFCJaWIcu9xYpJVE8jepKpSu9-OepD-Djcn11N_LIef3soIAW1Ql_T3FhRV8Qz20s4f0I39ebUz1tCcDEhB7Ad0sCLPlYderqUXlr26LludRc3AKmc-GFa6WoaRDGYEqr26gAlBzDXlWbhMZuQ2VPz0na8S=w958-h509-s-no)

![](https://lh3.googleusercontent.com/pw/AJFCJaWP1ou23KXwskhPu8YJmzUwXEF9u7jcRNju3TTH_7tVMMAs6aQzMhrR2HH0dCMzfnegfEx6Qeml4vtmlmq1YcZk78ko9jA4jpDmDpKJ9FFOU_tdOGWBRheXN6V9dxOPwr2bkVnYJTQZUJmITQaElKHa=w958-h506-s-no)

### Summary Button Calculations
![](https://lh3.googleusercontent.com/pw/AJFCJaV45nazQzs4oCB8RMNudEY4RlUYUdKIjE3vMS11itYDiOTJEW8IsNync62wnjSU5vRx-eQrduPCFSwooit4_g-gPfKBvsssDIy94IzFjJXGkKR9CRQsSNrCtiuhkqyTMSPW3FOKlafTkar3OxecCkT1=w958-h508-s-no)

### Reset Button
![](https://lh3.googleusercontent.com/pw/AJFCJaVh7UtnMGJuQQpuig2mfhkO-pdfsTejDtN2WrABKZvPaWjFZiCRZvcIVrdyhwXUFjaqT6a8KWGNEihqw6r1nf28XK01wcJK2Gee0-z6J8j-zOMWjkAivNixaHUeRQ5YFFHxpYL8E-NtVZvoFBZ2mYea=w958-h470-s-no)

### Displaying All Customers and Saving A New One
![](https://lh3.googleusercontent.com/pw/AJFCJaV2n_Y8XZhOpJrJz_i62W0AKLLXB-D1nd4Cx2vIYdxQDXH7n6LE3s989o0st-AyOIgdWvqnkIXEuYAlU939gf-m2GLo1nWmEocUrnfqmCDDUKNhUOdPsp9F0W52qsUlHqlFY8u8DZ0_6qhXxqMPWmUY=w958-h533-s-no)

### Search for Customers
![](https://lh3.googleusercontent.com/pw/AJFCJaWd2zMQeqn8tFHDR7ZhSPHTadC8x-Cil6bP58byuLoh1SWerLwv0aAEX4OZ32dcGwT9ZBXvEcswqetW8rk73LgkpGLri-EJdyaH0baWU8S7gTTpBZCrmaxlJPC_Yg4aXx-g6l6Q_dbySUx-NYG2Pmfe=w958-h533-s-no)

### Delete Customer
![](https://lh3.googleusercontent.com/pw/AJFCJaWBmIvorXTwLr_613fTJHTQlM5PJXKMVck3cH54EuRvV71yEK9y00fh3zj9dur_F560VN1VD35TQd5R64BN1jd6bNVHWA8UtDe-m6mudYPO1erpN2_SPFW2ak2RGnRYFoQi84DwGi45gmBZD0zZbltG=w958-h470-s-no)

### Insert Vehicle Make
![](https://lh3.googleusercontent.com/pw/AJFCJaUmxc3Fkt33pRQ1KRbk_RUjAnLi1pNbWEIcT69V16M2zzt3-Eq_zc4r0bmSbFNLzdbSW8Tez6Rvy2Swuylnbv9PqrZdCIhqi2aVREMAdXcWtHSywGC7FvalukFf53jJ-6pn9AKxKwhtPpYLZbFmRdsg=w958-h571-s-no)

## 📝 Licence
This project is licensed under the [MIT License](LICENSE).
