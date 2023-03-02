import {$authHost, $host} from "./index";
import jwtDecode from "jwt-decode";


export const registration = async (email,password) =>{
    const {data} = await $host.post('api/auth/registration', {email,password})
    localStorage.setItem('token',data.access_token)
    return jwtDecode(data.access_token)
}

export const login = async (email,password) =>{
    const {data} = await $host.post('api/auth/login', {email,password})
    localStorage.setItem('token',data.access_token)
    return jwtDecode(data.access_token)
}

export const check = async () =>{
    const {data} = await $authHost.get('api/auth')
    localStorage.setItem('token',data.access_token)
    return jwtDecode(data.access_token)
}