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
              "multipart/form-data": {
                "schema": {
                  "required": [
                    "Address",
                    "Contact",
                    "Name",
                    "Password",
                    "RoleId",
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
                    },
                    "Name": {
                      "maxLength": 256,
                      "type": "string"
                    },
                    "Address": {
                      "maxLength": 256,
                      "type": "string"
                    },
                    "Contact": {
                      "maxLength": 15,
                      "type": "string"
                    },
                    "RoleId": {
                      "type": "integer",
                      "format": "int32"
                    }
                  }
                },
                "encoding": {
                  "Username": {
                    "style": "form"
                  },
                  "Password": {
                    "style": "form"
                  },
                  "Name": {
                    "style": "form"
                  },
                  "Address": {
                    "style": "form"
                  },
                  "Contact": {
                    "style": "form"
                  },
                  "RoleId": {
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
      "/api/Auth/createpay": {
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
      "/api/Auth/updateuser": {
        "put": {
          "tags": [
            "Auth"
          ],
          "requestBody": {
            "content": {
              "multipart/form-data": {
                "schema": {
                  "required": [
                    "Address",
                    "Contact",
                    "Name",
                    "Password",
                    "RoleId",
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
                    },
                    "Name": {
                      "maxLength": 256,
                      "type": "string"
                    },
                    "Address": {
                      "maxLength": 256,
                      "type": "string"
                    },
                    "Contact": {
                      "maxLength": 15,
                      "type": "string"
                    },
                    "RoleId": {
                      "type": "integer",
                      "format": "int32"
                    }
                  }
                },
                "encoding": {
                  "Username": {
                    "style": "form"
                  },
                  "Password": {
                    "style": "form"
                  },
                  "Name": {
                    "style": "form"
                  },
                  "Address": {
                    "style": "form"
                  },
                  "Contact": {
                    "style": "form"
                  },
                  "RoleId": {
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
      "/api/Auth": {
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
      "/api/Product/AddBook": {
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
                    "discount",
                    "feedback",
                    "Id",
                    "Image",
                    "Name",
                    "price",
                    "Quantity",
                    "type"
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
                    "feedback": {
                      "type": "integer",
                      "format": "int32"
                    },
                    "price": {
                      "type": "number",
                      "format": "double"
                    },
                    "Quantity": {
                      "type": "integer",
                      "format": "int32"
                    },
                    "discount": {
                      "type": "number",
                      "format": "double"
                    },
                    "Id": {
                      "type": "integer",
                      "format": "int32"
                    },
                    "type": {
                      "maxLength": 256,
                      "type": "string"
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
                  "feedback": {
                    "style": "form"
                  },
                  "price": {
                    "style": "form"
                  },
                  "Quantity": {
                    "style": "form"
                  },
                  "discount": {
                    "style": "form"
                  },
                  "Id": {
                    "style": "form"
                  },
                  "type": {
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
      "/api/Product/{name}": {
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
      "/api/Product/Find/{category}": {
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
      "/api/Product/GetAll": {
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
      "/api/Product/Update": {
        "put": {
          "tags": [
            "Product"
          ],
          "requestBody": {
            "content": {
              "multipart/form-data": {
                "schema": {
                  "required": [
                    "Desc",
                    "discount",
                    "feedback",
                    "Image",
                    "Name",
                    "price",
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
                    "feedback": {
                      "type": "integer",
                      "format": "int32"
                    },
                    "price": {
                      "type": "number",
                      "format": "double"
                    },
                    "Quantity": {
                      "type": "integer",
                      "format": "int32"
                    },
                    "discount": {
                      "type": "number",
                      "format": "double"
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
                  "feedback": {
                    "style": "form"
                  },
                  "price": {
                    "style": "form"
                  },
                  "Quantity": {
                    "style": "form"
                  },
                  "discount": {
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
      "/api/Product/Delete/{id}": {
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
      }
    },
    "components": { }
  }