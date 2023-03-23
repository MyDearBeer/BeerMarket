import axios from "axios";
import {variables} from "../utils/consts";


const $host = axios.create({
    baseURL:variables.IDENTITY_URL
})

const $authHost = axios.create({
    baseURL:variables.IDENTITY_URL
})

const $authUser = axios.create({
    baseURL:variables.APP_URL
})

const authInterceptor = config => {
    config.headers.authorization = `Bearer ${localStorage.getItem('token')}`
    return config
}

$authHost.interceptors.request.use(authInterceptor)
$authUser.interceptors.request.use(authInterceptor)

export{
    $host,
    $authHost,
    $authUser
}