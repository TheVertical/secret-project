import React from "react"
import "./LinkBlock.css"
// Здесь будут состояния



//Здесь будут функции(внешние)




//Здесь будет главная функция экспорта 
const linkblock=(props)=>{

   let arr=[];
   for (let key in props.Links){
       arr.push(<a href={props.Links[key]} className="stylishAAA">{key}</a>)
       
   }
   
    return (
        
        <div className="blockStyle"> 
            {arr}
        </div>
    
        
        
        )

}





export default linkblock
