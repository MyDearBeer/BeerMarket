import Admin from "./pages/Admin"
import Autorisation from "./pages/Autorisation"
import Basket from "./pages/Basket"
import ItemPage from "./pages/ItemPage"
import Market from "./pages/Market"
import { ADMINROUTE, BASKETROUTE, ITEMROUTE, LOGINROUTE, REGROUTE, SHOPROUTE } from "./utils/consts"

export const authRoutes=[

{path:SHOPROUTE,element:<Market/>},
{path:ADMINROUTE,element:<Admin/>},
{path:BASKETROUTE,element:<Basket/>},
    {path:LOGINROUTE,element:<Autorisation/>},
    {path:ITEMROUTE+'/:id',element:<ItemPage/>},
    {path:REGROUTE,element:<Autorisation/>},
]

export const pubRoutes=[
    {path:SHOPROUTE,element:<Market/>},
    {path:LOGINROUTE,element:<Autorisation/>},
    {path:ITEMROUTE+'/:id',element:<ItemPage/>},
    {path:REGROUTE,element:<Autorisation/>},
 

]