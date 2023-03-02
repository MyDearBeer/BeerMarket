import React from 'react'
import ItemList from '../components/ItemList';
import Pages from '../components/Pages';
import SideBar from '../components/SideBar';
import UpBar from '../components/UpBar';
import './Market.css'

const Market = () => {
    return (
        <div>
           <SideBar/>
          
           <ItemList/>
           <Pages/>

        </div>
      );
}
 
export default Market;