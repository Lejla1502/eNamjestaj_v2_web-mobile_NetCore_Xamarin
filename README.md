# eNamjestaj-ASP.NetCore2.2


eNamjestaj is crossplatform ecommerce application built in **Asp.Net Core (C#)** and **Xamarin**. For backend data storage and retrieving was used **MSSQL**.
Web application provides different modules for two different types of users. Options for system **admin** is managing user data. **Manager** is allowed to manage products, action catalogues, categories, normatives, purchases, to process orders...
Mobile application is made for buyers. When they start application, they are given two options: to login or to register. After successful login, they are shown product page where they have two filters: category filter on the left and color filter on the right. After they click on "Pretraga" button, application shows them a list of products filtered by chosen option(s). Other functionalities, such are adding product to cart, accessing current order, accessing history of orders, seeing recommended products, leaving comments and rates, etc. are shown on screenshots below. 


# How to access application

After project is downloaded (VS Studio 2019 and SQL Server 2019 needed), and ran, user puts in credentials for his role.

Web application login info:

 * **Manager**: Menadzer (uername and password are the same)
 
 * **Admin**:   Admin (username and password are the same)

Mobile application login info:
 
 * **Buyer**:   Elvira (username and password are the same)

--->Web page soon available

# Technical details

Programms used for development are VS Studio 2019, SQL Server 2019.

**Web app**
 * .NET Core 2.2
 * C#
 * MVC
 * Cookie authentication
 * Unit tests
 * ML for .NET (Matrix factorization)
 * Reporting
 * jQuery
 * HTML
 * CSS, Bootstrap
 

**Mobile app**
 * .Xamarin
 * C#
 * MVVM
 * Basic authentication
 * Web API
 * Swagger
 * DI
 * AutoMapper


# Screenshots web app

![login_form](https://user-images.githubusercontent.com/22219433/136684071-6b34916e-4a4a-4b26-bd4e-48b9a096a787.png)

![start_page_admin](https://user-images.githubusercontent.com/22219433/136684073-9514d290-228f-44f1-b89d-a99ce39f14a4.png)

![employee_view_final](https://user-images.githubusercontent.com/22219433/136684070-ee0c50b3-5783-4040-9d9b-1c35f1de6af3.png)

![employee_edit](https://user-images.githubusercontent.com/22219433/136684068-0c252147-fcf8-4837-96ec-92971676e0e8.png)

![add_employee_1](https://user-images.githubusercontent.com/22219433/136684075-a5737d3a-7d8a-444e-be5e-2fab2da251db.png)

![add_employee_2](https://user-images.githubusercontent.com/22219433/136684076-da7df0c6-fca0-4bab-9d69-aaba34758970.png)

![customers_view](https://user-images.githubusercontent.com/22219433/136684078-6abd9a2f-c456-484c-bfa1-1115d233bc9e.png)

![customers_edit](https://user-images.githubusercontent.com/22219433/136684077-8b9d9e93-d763-4b5a-831d-3c2653e6832f.png)

![product_view](https://user-images.githubusercontent.com/22219433/136685315-429ed5ef-8250-4928-b4fc-358453c8b9f4.png)

![add_product1](https://user-images.githubusercontent.com/22219433/136685314-873a8cbb-ef25-448b-bc35-4352dcb64935.png)

![add_product2](https://user-images.githubusercontent.com/22219433/136685313-85c2249c-2941-4c6a-b196-b655fea44dd8.png)

![product_edit](https://user-images.githubusercontent.com/22219433/136685312-a4417c30-0e1e-4b5d-b559-70430d2d0743.png)

![catalogue_view](https://user-images.githubusercontent.com/22219433/136685311-9fac474d-3915-40ef-8cb4-db5356499f01.png)

![catalogue_products_view](https://user-images.githubusercontent.com/22219433/136685310-613f8d4a-87c2-4d15-aba2-caaace479430.png)

![order_view](https://user-images.githubusercontent.com/22219433/136685309-2f381d2d-0c78-464c-a5c2-ccc16cd52085.png)

![order_view_process](https://user-images.githubusercontent.com/22219433/136685308-ccd1394b-01c3-4104-827a-bf245a54ad22.png)

![normative_view](https://user-images.githubusercontent.com/22219433/136685318-72a317a7-59b7-45d3-be86-b4f60a50d711.png)

![normative_view_items](https://user-images.githubusercontent.com/22219433/136685317-137a79d1-34b4-4194-aff5-0b0b3321294e.png)

![purchase_view](https://user-images.githubusercontent.com/22219433/136685714-665c48ca-9bba-46b4-867d-68c1562b28a1.png)

![purchase_view_items](https://user-images.githubusercontent.com/22219433/136685719-726232cf-f8fd-40ff-ba88-70958b2cf7de.png)

![purchase_Add](https://user-images.githubusercontent.com/22219433/136685724-5583bb0e-8e86-47f4-884e-16c5e6e6ff63.png)

![purchase_items](https://user-images.githubusercontent.com/22219433/136685727-1f624311-5b5a-4b08-a337-0f9ed3ee3894.png)

![purchase_item_add](https://user-images.githubusercontent.com/22219433/136685731-95b3d1a5-818d-4540-9d5b-6bb3b5aff35f.png)

![purchase_item_addview](https://user-images.githubusercontent.com/22219433/136685733-101f0bde-f230-4f8c-9cc1-14c73aa332b8.png)

![product_manufact](https://user-images.githubusercontent.com/22219433/136685737-fdad4ebc-f47c-4851-b908-1d16e5b12c41.png)

![product_manufact_add](https://user-images.githubusercontent.com/22219433/136685745-f1209636-d672-41fa-83ca-f96051a8a540.png)


# Screenshots mobile app

![prijava](https://user-images.githubusercontent.com/22219433/136685794-c194e0c9-f7f1-4652-b556-8acd358273f3.png)

![registration](https://user-images.githubusercontent.com/22219433/136685869-364644d7-d18e-490b-ab64-2b2b0e39b1af.png)

![products](https://user-images.githubusercontent.com/22219433/136685879-6777c88d-9580-4572-b70a-b688ddb7c0b3.png)

![products_filtered](https://user-images.githubusercontent.com/22219433/136685890-26c1b6e7-6c60-4f86-90ea-205346e84b87.png)

![product_selected](https://user-images.githubusercontent.com/22219433/136685901-8d82e654-a985-422b-aa96-7c5b3ccb2e8c.png)

![purchase](https://user-images.githubusercontent.com/22219433/136685919-a17a860a-ed2e-4d96-8ba5-cd09a8b7cd23.png)

![purchased_items](https://user-images.githubusercontent.com/22219433/136685926-d896da93-6d48-4364-b001-2b2e3f4c9418.png)

![history_orders](https://user-images.githubusercontent.com/22219433/136685963-e0f5c028-984f-41ce-94c0-f0df2505ffd6.png)

![history_selected](https://user-images.githubusercontent.com/22219433/136685968-cbe7f2c5-f943-4c29-a49d-6de93402a29c.png)

![action_catalogue](https://user-images.githubusercontent.com/22219433/136685974-0a696a38-b005-41f6-a2c5-722d527a0c47.png)

![action_catalogue_selected](https://user-images.githubusercontent.com/22219433/136685983-d5b00e1f-f1b3-41ba-aa09-ffbf12db5390.png)

![comments](https://user-images.githubusercontent.com/22219433/136685995-0b1deaaa-c22b-4db9-9ce4-569f39224c2d.png)

![recom](https://user-images.githubusercontent.com/22219433/136686009-94fbeb3d-2abe-49fa-8644-634dea32dc18.png)

![profile](https://user-images.githubusercontent.com/22219433/136686021-515e05e4-642e-43f4-bc32-857d87e60f2a.png)

![edit](https://user-images.githubusercontent.com/22219433/136686028-49a16d13-a2bc-44b2-a42f-352deb77cc12.png)

