import React, { FunctionComponent as FC} from 'react';

interface ContactViewModel {
    PhoneNumber: string,
    WorkTime: string,
    ShowBackCall: boolean,
}

const name: React.FC<ContactViewModel> = (props) => {
const { PhoneNumber, WorkTime, ShowBackCall } = props;
    return(
        <div className='contact-form-container'>
            <span className='phone-number phone-number-white'>{PhoneNumber}</span>
            <span className='work-time'>{WorkTime}</span>
            {ShowBackCall ?? 
            <span className='request-callback'>
                // TODO: localize
                'ContactForm_RequestCallBack'
            </span>
            }
        </div>
    );
}

export default name;