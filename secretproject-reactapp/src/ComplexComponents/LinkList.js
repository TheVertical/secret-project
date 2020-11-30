import React from "react"
import "./LinkList.css"
// Здесь будут состояния



//Здесь будут функции(внешние)




//Здесь будет главная функция экспорта 
const linklist=(props)=>{

   let arr=[];
   for (let key in props.Links){
       arr.push(<a href={props.Links[key]} className="styleForLinkListElement">{key}</a>)
       
   }
   
    
           return(
            <div className="columnStyleForLinkList"> 
            <h3>{props.Title}</h3>
            {arr}
             </div>
           )
      
       
    
        

}





export default linklist