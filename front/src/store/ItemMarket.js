import { makeAutoObservable} from "mobx"
export default class ItemMarket{
    constructor(){
        this._type=[]  

this._factory=[
    // {id:1,facname:"Оболонь"},
    // {id:2,facname:"Перша приватна"}
]


        this._item=[
        
        ]

        this._basketItem=[

        ]

        this._selectedType={}
        this._selectedFactory={}
        this._page=1
        this._totalCount=0
        this._limit=10
        this._sumPrice = 0

makeAutoObservable(this)
    }

    setSelectedType(selectedType){
        this.setPage(1)
        this._selectedType=selectedType
    }

   get selectedType(){
       return this._selectedType
    }


    setSelectedFactory(selectedFactory){
        this.setPage(1)
        this._selectedFactory=selectedFactory
    }

   get selectedFactory(){
       return this._selectedFactory
    }

    get sumPrice(){
        return this._sumPrice
    }




    setSumPrice(sumPrice){
        this._sumPrice=sumPrice
    }


setType(type){
    this._type=type
}
setFactory(factory){
    this._factory=factory
}
setItem(item){
    this._item=item
}

setPage(page){
    this._page=page
}

setTotalCount(totalCount){
    this._totalCount=totalCount
}

setLimit(limit){
    this._limit=limit
}

setBasketItem(basketItem){
        this._basketItem=basketItem
}

get type(){
    return this._type
}
get factory(){
    return this._factory
}
get item(){
    return this._item
}

get page(){
    return this._page
}

get totalCount(){
    return this._totalCount
}

get limit(){
    return this._limit
}

get basketItem(){
        return this._basketItem
}

}