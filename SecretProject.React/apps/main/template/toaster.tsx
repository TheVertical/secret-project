import ToastItem from '@/models/toast-item';
import React from 'react';
import { connect } from 'react-redux';
import { RootState, AppDispatch } from '../store/store';
import ToastElement from './toaster-parts/toast-element';

interface ReduxStateProps {
    Toasts: ToastItem[];
}

interface DispatchProps {
    addToastItem: (toastItem: ToastItem | null) => void,
    deleteToastItem: (toastItem: ToastItem | null) => void
}

type Props = ReduxStateProps & DispatchProps;


const Toaster: React.FC<Props> = (props) => {
    const {
        Toasts,
        deleteToastItem
    } = props;

    const toaster = Toasts.map(item =>
        <ToastElement key={item.Id}
            toastItem={item}
            deleteToastItem={deleteToastItem} />);
    return (
        <div className="toaster-container">
            {toaster}
        </div>
    );
}

const mapStateToProps = (state: RootState): ReduxStateProps => {
    const Toasts = state.toaster.ToastItems;
    return { Toasts };
}

const mapDispatchToProps = (dispatch: AppDispatch) => {
    return {
        addToastItem: (toastItem: ToastItem) =>
            dispatch({ type: 'toaster-reducer/addToastItem', payload: toastItem }),
        deleteToastItem: (toastItem: ToastItem) =>
            dispatch({ type: 'toaster-reducer/deleteToastItem', payload: toastItem }),
    }
}

export default connect<ReduxStateProps, DispatchProps>(mapStateToProps, mapDispatchToProps)(Toaster);
