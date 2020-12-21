import MiniProductCard from "../ComplexComponents/MiniProductCard"

const initState = {
    Price:"",
    imageUrl:"",
    Title:"",
    Id:""
}

export default function rootReducer(state = initState, action) {
    switch (action.type) {
        case "InlineTrue":
            return {
                isInline: true,
                Style: "ProductCard_InlineStyle",
                ImageStyle: "ProductCard_ImageInlineStyle"
            }
        case "InlineFalse":
            return {
                isInline: false,
                Style: "ProductCard_BlockStyle",
                ImageStyle: "ProductCard_ImageBlockStyle",
            }
        case "GetMiniProductCard":
        return{
                Price:action.Price,
                ImageUrl:action.ImageUrl,
                Title:action.Title,
                Id:action.Id
            }

            default: return state

        }
        

}