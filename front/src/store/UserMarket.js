import { makeAutoObservable} from "mobx"
export default class UserMarket{
    constructor(){
        this._user={}
this._isAuth=false
makeAutoObservable(this)
    }


setisAuth(bool){
    this._isAuth=bool
}
get isAuth(){
    return this._isAuth
}
get User(){
    return this._user
}

setUser(user){
    this._user=user
}


}