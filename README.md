# StockSense API 
Product Inventory Management API Documentation

## Introduction
The Product Inventory Management API allows users to manage products, categories, suppliers, and generate inventory reports. This documentation provides an overview of the API endpoints, their functionality, and usage instructions.

## Base URL
The base URL for all API endpoints is `https://api.example.com`. !!!!No Active endpoint yet!!!!

## Authentication
Authentication is required to access the API endpoints. All requests must include an `Authorization` header with a valid access token.

## Endpoints

### Retrieve All Products

#### GET /api/products

Returns a list of all products in the inventory.

##### Request

```
GET /api/products
```

##### Response

```json
Status: 200 OK
[
    {
        "productId": 1,
        "name": "Product 1",
        "description": "Description of Product 1",
        "price": 10.99,
        "quantity": 50,
        "categoryId": 1,
        "supplierId": 1
    },
    ...
]
```

### Retrieve Product by ID

#### GET /api/products/{id}

Returns the product with the specified ID.

##### Request

```
GET /api/products/{id}
```

##### Response

```json
Status: 200 OK
{
    "productId": 1,
    "name": "Product 1",
    "description": "Description of Product 1",
    "price": 10.99,
    "quantity": 50,
    "categoryId": 1,
    "supplierId": 1
}
```

### Add Product

#### POST /api/products

Adds a new product to the inventory.

##### Request

```
POST /api/products
Content-Type: application/json

{
    "name": "New Product",
    "description": "Description of New Product",
    "price": 19.99,
    "quantity": 100,
    "categoryId": 2,
    "supplierId": 1
}
```

##### Response

```json
Status: 200 OK
"Product Added"
```

### Update Product

#### PUT /api/products/{id}

Updates the product with the specified ID.

##### Request

```
PUT /api/products/{id}
Content-Type: application/json

{
    "name": "Updated Product",
    "description": "Updated description",
    "price": 24.99,
    "quantity": 75,
    "categoryId": 2,
    "supplierId": 1
}
```

##### Response

```json
Status: 200 OK
"Product Updated"
```

### Delete Product

#### DELETE /api/products/{id}

Deletes the product with the specified ID.

##### Request

```
DELETE /api/products/{id}
```

##### Response

```json
Status: 200 OK
"Product Deleted"
```

### Add Category

#### POST /api/products/category

Adds a new category for products.

##### Request

```
POST /api/products/category
Content-Type: application/json

{
    "name": "New Category"
}
```

##### Response

```json
Status: 200 OK
"Category Added"
```

### Add Supplier

#### POST /api/products/supplier

Adds a new supplier for products.

##### Request

```
POST /api/products/supplier
Content-Type: application/json

{
    "name": "New Supplier",
    "contactNumber": "+1234567890",
    "email": "supplier@example.com"
}
```

##### Response

```json
Status: 200 OK
"Supplier Added"
```

### Get Stock Summary



#### GET /api/products/report

Generates an inventory report summarizing the stock.

##### Request

```
GET /api/products/report
```

##### Response

```json
Status: 200 OK
{
    "reportName": "Inventory Summary",
    "totalValue": 2500.75,
    "stockSummaryItems": [
        {
            "productId": 1,
            "productName": "Product 1",
            "stockQuantity": 50,
            "stockValue": 549.50
        },
        ...
    ]
}
```

### Increase Stock

#### POST /api/products/{id}/increaseStock

Increases the stock quantity of the product with the specified ID.

##### Request

```
POST /api/products/{id}/increaseStock
Content-Type: application/json

{
    "quantity": 25
}
```

##### Response

```json
Status: 200 OK
"Stock increased by 25 for product with ID {id}."
```

### Decrease Stock

#### POST /api/products/{id}/decreaseStock

Decreases the stock quantity of the product with the specified ID.

##### Request

```
POST /api/products/{id}/decreaseStock
Content-Type: application/json

{
    "quantity": 10
}
```

##### Response

```json
Status: 200 OK
"Stock decreased by 10 for product with ID {id}."
```

## Error Responses

- `400 Bad Request`: The request is invalid or missing required fields.
- `404 Not Found`: The requested resource is not found.

## Conclusion

This concludes the documentation for the Product Inventory Management API. For any further assistance or inquiries, please contact our support team at support@example.com.
