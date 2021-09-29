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
    UserRoleId: number;
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

