export interface Item
{
    ItemId: number;
    ItemName: string;
    ItemDescription: string;
    SubCategoryId: number;
    SubCategory?: SubCategory;
    ItemPrice: number;    
    ItemDiscount: number;    
    ItemAmount: number;

};

export interface CartItem
{
    ItemId: number;
    ItemName: string;
    AmountInCart: number;
    ItemPrice: number;
}

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
    Category?: Category;
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
    UserId: number;
    OrderStatus: string;
};

