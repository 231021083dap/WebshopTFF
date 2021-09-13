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
};