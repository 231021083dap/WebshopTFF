import { DeclarationListEmitMode } from "@angular/compiler";

export interface Item
{
    ItemId: number;
    ItemName: String;
    ItemSubCategory: String;
    ItemPrice: number;
    ItemOnSale: Boolean;
    DiscountPercent: number;
    ItemInStock: Boolean;
    AmountInStorage: number;

};

export interface User
{
    UserId: number;
    UserRoleId: number;
    Email: String;
    TLF: number;
    Password: string;
    FirstName: String;
    LastName: String;
    MiddleName?: String;
    Address: String;
    PostalCode: number; 
    Token?: string;
};

export interface Category
{
    CategoryId: number;
    CategoryName: String;
};

export interface SubCategory
{
    SubId: number;
    SubName: string;
    CategoryId: number;
}

export interface Roles
{
    RoleId: number;
    RoleName: string;
};

export interface Order
{
    OrderId: number;
    Userid: number;
    OrderDate: Date; 
};

