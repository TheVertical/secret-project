import React, { FunctionComponent as FC} from 'react';

interface ContactViewModel {
    PhoneNumber: string,
    WorkTime: string,
    ShowBackCall: boolean,
}

const ContactForm: React.FC<ContactViewModel> = (props) => {
const { PhoneNumber, WorkTime, ShowBackCall } = props;
    return(
        <div className='contact-form-container'>
            <div className='phone-number phone-number-white'>{PhoneNumber}</div>
            <div className='work-time'>{WorkTime}</div>
            {ShowBackCall ?? 
            <div className='request-callback'>
                // TODO: localize
                'ContactForm_RequestCallBack'
            </div>
            }
        </div>
    );
}

export default ContactForm;