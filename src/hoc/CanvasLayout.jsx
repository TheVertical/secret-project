import React from 'react';
import SelectButton from '../visualElements/SelectButton'
import { MakeServerQuery, GetSettings } from '../Services/ServerQuery'

class CanvasLayout extends React.Component {
   constructor(props) {
      super(props);
      this.state = {
      }
   }

   componentDidMount() {
   }

   render() {
      return (
         <div>
            <SelectButton actionShema="catalog/category/*value*" objectArray={[{ title: 'Гигиена', value: '1' }, { title: 'Дезинф', value: '2' }, { title: 'Кораблб', value: '3' }]}>
               SelectButton
            </SelectButton>
         </div>
      );
   }


}

export default CanvasLayout;
