import React, { useState } from 'react';
import { Button, ButtonGroup, Form } from 'react-bootstrap';

interface CounterButtonProps {
    initialValue?: number
    variant?: string,
    maxValue?: number,
    minValue?: number,
    size?: 'sm' | 'lg' | undefined,
    showMinus?: boolean,
    showPlus?: boolean,

    updateCount: (count: number) => void,
}

interface CounterButtonState {
    count: number
}

const CounterButton: React.FC<CounterButtonProps> = (props) => {

    const initialValue = props.initialValue ?? 0,
        variant = props.variant ?? 'primary',
        maxValue = props.maxValue ?? Number.MAX_SAFE_INTEGER,
        minValue = props.minValue ?? Number.MIN_SAFE_INTEGER,
        size = props.size ?? 'sm',
        showMinus = props.showMinus ?? true,
        showPlus = props.showPlus ?? true;

    if (initialValue > maxValue || initialValue < minValue) {
        throw new Error('Initial value is out of min/max range!');
    }

    const { updateCount } = props;

    const [counterButtonState, setstate] = useState<CounterButtonState>({ count: initialValue ?? 0 });

    const actionOnButtonClick = function (plus: boolean) {
        var count = counterButtonState.count;
        count = plus ? count + 1 : count - 1;
        if (count <= maxValue && count >= minValue) {
            setstate({ count });
            updateCount(count);
        }
    }

    const actionOnInput = function (value: number) {
        var count = value;
        if (count <= maxValue && count >= minValue) {
            setstate({ count });
            updateCount(count);
        }
    }

    return (
        <ButtonGroup className="counter" size={size}>
            {showMinus && <Button variant={variant} onClick={() => actionOnButtonClick(false)}>-</Button>}
            <input className={variant + " text-center p-2"} type="number" value={counterButtonState.count} onChange={(event) => { actionOnInput(Number(event.target.value)) }} placeholder={String(initialValue)} />
            {showPlus && <Button variant={variant} onClick={() => actionOnButtonClick(true)}>+</Button>}
        </ButtonGroup>
    );
}

export default CounterButton;