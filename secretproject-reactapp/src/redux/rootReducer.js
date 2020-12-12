const initState={
    isInline:false
}

export default function rootReducer(state=initState,action){
     switch(action.type){
      case "InlineTrue":
          return{
              isInline:true
          }
       case "InlineFalse":
            return{
                isInline:false
            }
     }
      
    
    
    return state
}