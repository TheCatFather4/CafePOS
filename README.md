# CafePOS

![Menu2](https://github.com/user-attachments/assets/70a10c63-8fe6-4e12-a6a0-48d193e76ec4)

## About
An n-tier console application that lets cafe servers (employees) implement point-of-sale transactions.
The 4th Wall Cafe POS queries data from the 4th Wall Cafe Database using Entity Framework.

## Key Features

### 1. Creating New Orders
A list of available servers will be displayed on the screen for selection.
After choosing a valid server ID, the user will be notified that a new order has been created with a unique ID for that order.

### 2. Adding Items to Orders
A list of open orders (unpaid) will be presented on the screen. Upon selection of an order ID, the user will be shown a list
of categories to choose from. Next, items in that category will be displayed in accord with the current time of day configuration.
The user will be prompted to enter a quantity of the item, and asked if they would like to add any more items to the order.
If the user decides that they would like to add more items, they will be brought back to the categories menu.

### 3. Processing Payments
After selecting an order from the list, the user will be brought to an order totals screen. The user has the ability to add a tip to the order.
If added, a new box will appear with the new total, as well as the tip amount that was added. If a customer ordered more than 15 items, there is a mandatory 15% tip added to the order.
The user can add more to the tip if the customer requests. Next, the user is brought to the payment type screen and can select a preferred method of payment, followed by a confirmation message.

### 4. Viewing Open Orders
This feature allows users to see a list of open orders and check what items, if any, are associated with each particular order.

### 5. Canceling Orders
Users can cancel orders, but only orders that are unpaid (open orders). Orders that have been already paid cannot be canceled.

### 6. Printing Monthly Sales Reports
Upon entering a date in short string format, users can access a daily sales report. 
Totals for each business day is listed, however tax and tip amounts are not included in the report.

![Report](https://github.com/user-attachments/assets/31b4c9ca-2531-4142-8691-b43976421984)

## Configuration Settings

### 1. Time of Day
There are several time of day settings that can be implemented: Breakfast, Lunch, Dinner, Happy Hour, Seasonal, and Real Time.
Most users will benefit from using the real time setting, but specific meal times are available for training or special purposes.

### 2. Training Mode
The application can be set to a training mode where users can practice placing orders. 
A mock database is implemented for this purpose, allowing new servers to practice their point-of-sale skills.

![Menu](https://github.com/user-attachments/assets/37b3bf2d-4f67-433a-aa89-f8f58a707bd2)

## Notes
A connection string and container is required to access the 4th Wall Cafe database. 

4th Wall Cafe Database is property of Skill Foundry (skillfoundry.io).
