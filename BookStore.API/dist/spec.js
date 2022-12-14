var spec =
{
    "openapi": "3.0.1",
    "info": {
        "title": "BookStore.API",
        "version": "1.0"
    },
    "paths": {
        "/api/Auth/register": {
            "post": {
                "tags": [
                    "Auth"
                ],
                "requestBody": {
                    "content": {
                        "application/json": {
                            "schema": {
                                "$ref": "#/components/schemas/AuthUserDto"
                            }
                        },
                        "text/json": {
                            "schema": {
                                "$ref": "#/components/schemas/AuthUserDto"
                            }
                        },
                        "application/*+json": {
                            "schema": {
                                "$ref": "#/components/schemas/AuthUserDto"
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Auth/login": {
            "post": {
                "tags": [
                    "Auth"
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "Password",
                                    "Username"
                                ],
                                "type": "object",
                                "properties": {
                                    "Username": {
                                        "maxLength": 256,
                                        "type": "string"
                                    },
                                    "Password": {
                                        "maxLength": 256,
                                        "type": "string"
                                    }
                                }
                            },
                            "encoding": {
                                "Username": {
                                    "style": "form"
                                },
                                "Password": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Auth/Image/{id}": {
            "put": {
                "tags": [
                    "Auth"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "requestBody": {
                    "content": {
                        "application/json": {
                            "schema": {
                                "$ref": "#/components/schemas/UserImage"
                            }
                        },
                        "text/json": {
                            "schema": {
                                "$ref": "#/components/schemas/UserImage"
                            }
                        },
                        "application/*+json": {
                            "schema": {
                                "$ref": "#/components/schemas/UserImage"
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Auth/pay": {
            "post": {
                "tags": [
                    "Auth"
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "PayType",
                                    "UserId"
                                ],
                                "type": "object",
                                "properties": {
                                    "UserId": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "PayType": {
                                        "maxLength": 256,
                                        "type": "string"
                                    }
                                }
                            },
                            "encoding": {
                                "UserId": {
                                    "style": "form"
                                },
                                "PayType": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Auth/logout": {
            "get": {
                "tags": [
                    "Auth"
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Auth/{id}": {
            "put": {
                "tags": [
                    "Auth"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "requestBody": {
                    "content": {
                        "application/json": {
                            "schema": {
                                "$ref": "#/components/schemas/AuthUpdateDto"
                            }
                        },
                        "text/json": {
                            "schema": {
                                "$ref": "#/components/schemas/AuthUpdateDto"
                            }
                        },
                        "application/*+json": {
                            "schema": {
                                "$ref": "#/components/schemas/AuthUpdateDto"
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Auth/Password/{id}": {
            "put": {
                "tags": [
                    "Auth"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "requestBody": {
                    "content": {
                        "application/json": {
                            "schema": {
                                "$ref": "#/components/schemas/ChangePass"
                            }
                        },
                        "text/json": {
                            "schema": {
                                "$ref": "#/components/schemas/ChangePass"
                            }
                        },
                        "application/*+json": {
                            "schema": {
                                "$ref": "#/components/schemas/ChangePass"
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Cart": {
            "post": {
                "tags": [
                    "Cart"
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "IdUser"
                                ],
                                "type": "object",
                                "properties": {
                                    "IdUser": {
                                        "type": "integer",
                                        "format": "int32"
                                    }
                                }
                            },
                            "encoding": {
                                "IdUser": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Cart/{id}": {
            "get": {
                "tags": [
                    "Cart"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            },
            "delete": {
                "tags": [
                    "Cart"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Cart/CartItem": {
            "post": {
                "tags": [
                    "Cart"
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "IdCart",
                                    "IdProduct",
                                    "Quantity"
                                ],
                                "type": "object",
                                "properties": {
                                    "IdProduct": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "IdCart": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "Quantity": {
                                        "type": "integer",
                                        "format": "int32"
                                    }
                                }
                            },
                            "encoding": {
                                "IdProduct": {
                                    "style": "form"
                                },
                                "IdCart": {
                                    "style": "form"
                                },
                                "Quantity": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Cart/CartItem/{id}": {
            "delete": {
                "tags": [
                    "Cart"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Product": {
            "post": {
                "tags": [
                    "Product"
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "Desc",
                                    "Discount",
                                    "Feedback",
                                    "IdCate",
                                    "Image",
                                    "Name",
                                    "Price",
                                    "Quantity"
                                ],
                                "type": "object",
                                "properties": {
                                    "Name": {
                                        "maxLength": 256,
                                        "type": "string"
                                    },
                                    "Image": {
                                        "maxLength": 256,
                                        "type": "string"
                                    },
                                    "Desc": {
                                        "maxLength": 4096,
                                        "type": "string"
                                    },
                                    "Feedback": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "Price": {
                                        "type": "number",
                                        "format": "double"
                                    },
                                    "Quantity": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "Discount": {
                                        "type": "number",
                                        "format": "double"
                                    },
                                    "IdCate": {
                                        "type": "integer",
                                        "format": "int32"
                                    }
                                }
                            },
                            "encoding": {
                                "Name": {
                                    "style": "form"
                                },
                                "Image": {
                                    "style": "form"
                                },
                                "Desc": {
                                    "style": "form"
                                },
                                "Feedback": {
                                    "style": "form"
                                },
                                "Price": {
                                    "style": "form"
                                },
                                "Quantity": {
                                    "style": "form"
                                },
                                "Discount": {
                                    "style": "form"
                                },
                                "IdCate": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            },
            "get": {
                "tags": [
                    "Product"
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Product/ProductFeed": {
            "post": {
                "tags": [
                    "Product"
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "Comment",
                                    "ProductID",
                                    "star",
                                    "UserID"
                                ],
                                "type": "object",
                                "properties": {
                                    "Comment": {
                                        "maxLength": 256,
                                        "type": "string"
                                    },
                                    "star": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "ProductID": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "UserID": {
                                        "type": "integer",
                                        "format": "int32"
                                    }
                                }
                            },
                            "encoding": {
                                "Comment": {
                                    "style": "form"
                                },
                                "star": {
                                    "style": "form"
                                },
                                "ProductID": {
                                    "style": "form"
                                },
                                "UserID": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Product/Name/{name}": {
            "get": {
                "tags": [
                    "Product"
                ],
                "parameters": [
                    {
                        "name": "name",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "string"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Product/Categrory/{category}": {
            "get": {
                "tags": [
                    "Product"
                ],
                "parameters": [
                    {
                        "name": "category",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Product/ProductFeed/{id}": {
            "get": {
                "tags": [
                    "Product"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Product/Category": {
            "get": {
                "tags": [
                    "Product"
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Product/{Id}": {
            "put": {
                "tags": [
                    "Product"
                ],
                "parameters": [
                    {
                        "name": "Id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "Desc",
                                    "Discount",
                                    "Feedback",
                                    "IdCate",
                                    "Image",
                                    "Name",
                                    "Price",
                                    "Quantity"
                                ],
                                "type": "object",
                                "properties": {
                                    "Name": {
                                        "maxLength": 256,
                                        "type": "string"
                                    },
                                    "Image": {
                                        "maxLength": 256,
                                        "type": "string"
                                    },
                                    "Desc": {
                                        "maxLength": 4096,
                                        "type": "string"
                                    },
                                    "Feedback": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "Price": {
                                        "type": "number",
                                        "format": "double"
                                    },
                                    "Quantity": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "Discount": {
                                        "type": "number",
                                        "format": "double"
                                    },
                                    "IdCate": {
                                        "type": "integer",
                                        "format": "int32"
                                    }
                                }
                            },
                            "encoding": {
                                "Name": {
                                    "style": "form"
                                },
                                "Image": {
                                    "style": "form"
                                },
                                "Desc": {
                                    "style": "form"
                                },
                                "Feedback": {
                                    "style": "form"
                                },
                                "Price": {
                                    "style": "form"
                                },
                                "Quantity": {
                                    "style": "form"
                                },
                                "Discount": {
                                    "style": "form"
                                },
                                "IdCate": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Product/{id}": {
            "delete": {
                "tags": [
                    "Product"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Store/Order": {
            "post": {
                "tags": [
                    "Store"
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "Address",
                                    "IdUser",
                                    "Total"
                                ],
                                "type": "object",
                                "properties": {
                                    "IdUser": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "Address": {
                                        "type": "string"
                                    },
                                    "Total": {
                                        "type": "integer",
                                        "format": "int32"
                                    }
                                }
                            },
                            "encoding": {
                                "IdUser": {
                                    "style": "form"
                                },
                                "Address": {
                                    "style": "form"
                                },
                                "Total": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Store/OrderProduct": {
            "post": {
                "tags": [
                    "Store"
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "IdOrder",
                                    "IdProduct",
                                    "Price",
                                    "Quantity"
                                ],
                                "type": "object",
                                "properties": {
                                    "IdOrder": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "IdProduct": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "Quantity": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "Price": {
                                        "type": "number",
                                        "format": "double"
                                    }
                                }
                            },
                            "encoding": {
                                "IdOrder": {
                                    "style": "form"
                                },
                                "IdProduct": {
                                    "style": "form"
                                },
                                "Quantity": {
                                    "style": "form"
                                },
                                "Price": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Store/Payment": {
            "post": {
                "tags": [
                    "Store"
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "Amount",
                                    "IdOrder",
                                    "TypePay"
                                ],
                                "type": "object",
                                "properties": {
                                    "IdOrder": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "Amount": {
                                        "type": "integer",
                                        "format": "int32"
                                    },
                                    "Date": {
                                        "type": "string",
                                        "format": "date-time"
                                    },
                                    "TypePay": {
                                        "type": "integer",
                                        "format": "int32"
                                    }
                                }
                            },
                            "encoding": {
                                "IdOrder": {
                                    "style": "form"
                                },
                                "Amount": {
                                    "style": "form"
                                },
                                "Date": {
                                    "style": "form"
                                },
                                "TypePay": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Store/MethodPay": {
            "post": {
                "tags": [
                    "Store"
                ],
                "requestBody": {
                    "content": {
                        "multipart/form-data": {
                            "schema": {
                                "required": [
                                    "TypeName"
                                ],
                                "type": "object",
                                "properties": {
                                    "TypeName": {
                                        "type": "string"
                                    }
                                }
                            },
                            "encoding": {
                                "TypeName": {
                                    "style": "form"
                                }
                            }
                        }
                    }
                },
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Store/Order/{id}": {
            "get": {
                "tags": [
                    "Store"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Store/OrderProduct/{id}": {
            "get": {
                "tags": [
                    "Store"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Store/Payment/{id}": {
            "get": {
                "tags": [
                    "Store"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Store": {
            "get": {
                "tags": [
                    "Store"
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        },
        "/api/Store/{id}": {
            "delete": {
                "tags": [
                    "Store"
                ],
                "parameters": [
                    {
                        "name": "id",
                        "in": "path",
                        "required": true,
                        "schema": {
                            "type": "integer",
                            "format": "int32"
                        }
                    }
                ],
                "responses": {
                    "200": {
                        "description": "Success"
                    }
                }
            }
        }
    },
    "components": {
        "schemas": {
            "AuthUpdateDto": {
                "required": [
                    "address",
                    "contact",
                    "email",
                    "name"
                ],
                "type": "object",
                "properties": {
                    "name": {
                        "maxLength": 256,
                        "type": "string"
                    },
                    "address": {
                        "maxLength": 256,
                        "type": "string"
                    },
                    "contact": {
                        "maxLength": 15,
                        "type": "string"
                    },
                    "email": {
                        "maxLength": 256,
                        "type": "string"
                    }
                },
                "additionalProperties": false
            },
            "AuthUserDto": {
                "required": [
                    "address",
                    "contact",
                    "email",
                    "name",
                    "password",
                    "roleId",
                    "username"
                ],
                "type": "object",
                "properties": {
                    "username": {
                        "maxLength": 256,
                        "type": "string"
                    },
                    "password": {
                        "maxLength": 256,
                        "type": "string"
                    },
                    "name": {
                        "maxLength": 256,
                        "type": "string"
                    },
                    "address": {
                        "maxLength": 256,
                        "type": "string"
                    },
                    "contact": {
                        "maxLength": 15,
                        "type": "string"
                    },
                    "email": {
                        "maxLength": 256,
                        "type": "string"
                    },
                    "roleId": {
                        "type": "integer",
                        "format": "int32"
                    }
                },
                "additionalProperties": false
            },
            "ChangePass": {
                "required": [
                    "password",
                    "rePassword"
                ],
                "type": "object",
                "properties": {
                    "password": {
                        "maxLength": 256,
                        "type": "string"
                    },
                    "rePassword": {
                        "maxLength": 256,
                        "type": "string"
                    }
                },
                "additionalProperties": false
            },
            "UserImage": {
                "required": [
                    "userimage"
                ],
                "type": "object",
                "properties": {
                    "userimage": {
                        "maxLength": 256,
                        "type": "string"
                    }
                },
                "additionalProperties": false
            }
        }
    }
}
1