import React, { FunctionComponent as FC} from 'react';
import Header from './Header';

const Layout: React.FC = (props) => {
    const PhoneNumber: string = '8 (812) 388-4538';
    const WorkTime: string = 'ПН-Чт: 10 : 00 - 18 : 00, Пт: 10 : 00 - 17 : 00';
    return(
        <>
            <Header
                PhoneNumber={PhoneNumber}
                WorkTime={WorkTime}
                />
        </>
    );
}

export default Layout;