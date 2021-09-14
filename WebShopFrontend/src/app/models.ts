// import { DeclarationListEmitMode } from "@angular/compiler";

export interface Item
{
    ItemId: number;
    ItemName: string;
    ItemSubCategory: string;
    ItemPrice: number;    
    ItemDiscount: number;    
    ItemAmount: number;

};

export interface User
{
    UserId: number;
    UserRoleId: number;
    Email: string;
    Phone: number;
    Password: string;
    FirstName: string;
    LastName: string;
    MiddleName?: string;
    Address: string;
    PostalCode: number; 
    Token?: string;
};

export interface Category
{
    CategoryId: number;
    CategoryName: string;
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

