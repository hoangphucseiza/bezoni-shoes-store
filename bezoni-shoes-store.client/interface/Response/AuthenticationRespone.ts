export interface AuthenticationRespone {
    user: {
        id: string;
        username: string;
        fullname: string;
        email: string;
        phone: string;
        address: string;
        avatar: string;
        role: string;  
    };
    token: string;
    refreshToken: string;
}