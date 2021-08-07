import React from 'react';
import { connect } from 'react-redux';
import AuthorizationModal from '../common-components/authorizatiom-modal';
import { useAppDispatch } from '../store/hooks';
import { AppDispatch, RootState } from '../store/store';

interface ReduxStateProps {
    authorizationModal: boolean | null;
}

interface DispatchProps {
    toggleAuthorizationModal: () => void
}

type Props = ReduxStateProps & DispatchProps;

const LayoutModals: React.FC<Props> = (props) => {
    const {
        authorizationModal
    } = props;
    
    const {
        toggleAuthorizationModal
    } = props;
    
    return(
        <>
            {authorizationModal && <AuthorizationModal closeModal={toggleAuthorizationModal}/>}
        </>
    );
}

const mapStateToProps = (state: RootState): ReduxStateProps => {
    const {
    authorizationModal
    } = state.layoutModals;
    
    return { authorizationModal };
}

const mapDispatchToProps = (dispatch: AppDispatch) => {
    return {
      toggleAuthorizationModal: () => dispatch({ type: 'layout-modals/toggleAuthorizationModal' }),
    }
}

export default connect<ReduxStateProps, DispatchProps>(mapStateToProps, mapDispatchToProps)(LayoutModals);
