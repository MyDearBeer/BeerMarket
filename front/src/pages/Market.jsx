import React from 'react'
import ItemList from '../components/ItemList';
import Pages from '../components/Pages';
import SideBar from '../components/SideBar';
import UpBar from '../components/UpBar';
import './Market.css'

const Market = () => {
    return (
        <div className="market">
           <SideBar/>
          <div>
           <ItemList/>
           <Pages/>
          </div>
        </div>
      );
}
 
export default Market;