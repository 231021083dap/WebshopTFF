// import { DeclarationListEmitMode } from "@angular/compiler";

export interface Item
{
    ItemId: number;
    ItemName: string;
    ItemDescription: string;
    SubCategoryId: number;
    ItemPrice: number;    
    ItemDiscount: number;    
    ItemAmount: number;

};

export interface User
{
    UserId: number;
    Role?: Role;
    Email: string;
    Phone: string;
    Password: string;
    FirstName: string;
    LastName: string;
    MiddleName?: string;
    Address: string;
    PostalCode: string; 
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

export enum Role
{
    Customer = 'Customer',
    Employee = 'Employee',
    Admin = 'Admin',
    SuperUser = 'SuperUser'
};

export interface Order
{
    OrderId: number;
    Userid: number;
    OrderDate: Date; 
};

