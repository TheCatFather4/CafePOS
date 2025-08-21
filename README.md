# CafePOS

![Menu2](https://github.com/user-attachments/assets/70a10c63-8fe6-4e12-a6a0-48d193e76ec4)

## About
An n-tier console application that allows cafe employees (servers) the ability to establish point-of-sale transactions.</br>
This application queries data from a database using Entity Framework.

## Key Features

### 1. Creating New Orders
Cafe servers can create new orders for further processing.
The available servers for work will be displayed on the screen for selection.
After choosing a valid server ID, the user will be notified that a new order has been created with a unique ID.
This ID will allow the user to easily locate and add items to the order.

### 2. Adding Items to Orders
Once an order is created, servers can add as many items as they would like to it.
A list of open (unpaid) orders will be presented on the screen. 
Upon selection of an order ID, the user will be shown a list of categories to choose from. 
Next, items in the category selected will be displayed in accord with the current time of day configuration.
After this selection, the user will be prompted to enter a quantity of the item, and asked if they would like to add any more items to the order.
If the user decides that they would like to add more items, they will be brought back to the categories menu.
At any time, the user can press '0' to quit and go back to the main menu. 
This sub-feature allows cafe servers to quickly "back out" incase an item or quantity was added by mistake.

### 3. Processing Payments
When an order has items added to it, the user can then process it for payment when needed. 
An order will be selected from a menu, and the user will be brought to an order totals screen. 
Next, the option to add a tip will be available.
If a tip is added, a new box will appear with both the new total and the tip amount.
A mandatory tip of 15% is added to orders that have more than 15 items.
The user can add more to the tip if the customer requests.
After the total is calculated, the user is brought to the payment type screen and can select a preferred method of payment.

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
There are several time of day settings that can be implemented: Breakfast, Lunch, Dinner, Happy Hour, Seasonal, and Real Time.</br>
Most users will benefit from using the real time setting, but specific meal times are available for training or special purposes.

### 2. Training Mode
The application can be set to a training mode where users can practice placing orders.</br>
A mock database is implemented for this purpose, allowing new servers to practice their point-of-sale skills.

![Menu](https://github.com/user-attachments/assets/37b3bf2d-4f67-433a-aa89-f8f58a707bd2)

> [!NOTE]
A connection string and container is required to access the database.</br>
The Database and Entity Relationship Diagram can be found at (skillfoundry.io).
