export interface User {
    id: number;
    name: string;
    email: string;
    mobileNo: string;
    address: string;
    createdDate: Date;
    roleId: number;
    roleName?: string;
}
