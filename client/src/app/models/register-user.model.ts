import { City } from "./city.model";

export interface RegisterUser{
    email : string,
    password : string,
    confirmpassword : string,
    city : City
    }