import React from 'react';
import { ClockLoader } from 'react-spinners';
import { VisualConstants } from '../constants';

const Loader: React.FC = () => {
    return(
        <div className="loader-wrapper d-flex flex-wrap align-content-center justify-content-center">
            <ClockLoader loading={true} color={VisualConstants.MainColors.OCEANIC_DARK} size={50}/>
        </div>
    );
}

export default Loader;