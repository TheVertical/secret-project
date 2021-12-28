import HierarchyElement from '@/shared/models/HierarchyElement';
import React from 'react';
import { Button, Dropdown } from 'react-bootstrap';
import { DropdownMenuProps } from 'react-bootstrap/esm/DropdownMenu';

interface HirarchyButtonProps {
    root: HierarchyElement,
    location: 'top' | 'bottom' | 'left' | 'right',
    actionToElement: (id: string, parent: boolean) => void,
    applyActoinOnlyToEndChildren: boolean
};

const HirarchyButton: React.FC<HirarchyButtonProps> = (props) => {
    const {
        root,
        location,
        actionToElement,
        applyActoinOnlyToEndChildren } = props;

    const renderNode = function (node: HierarchyElement): any {
        if (node.Children.length == 0) {
            return (
                <div className="hierarchy-item">
                    <Button variant='secondary'>{node.Name}</Button>
                </div>
            );
        }

        return (
            <div className="hierarchy-item">
                <Button variant='secondary'>{node.Name}</Button>
                <div className={"hierarchy-menu location-" + location}>
                    {node.Children.map(n => renderNode(n))}
                </div>
            </div>
        );
    };

    return (
        <div className="hierarchy">
            <Button variant="secondary" className={"hierarchy-btn location-" + location}>
                {root.Name}
                <div className="show after-hierarchy-button"/>
            </Button>
            <div className={"hierarchy-menu root-menu pb-3 pt-3 show location-" + location}>
                {root.Children.map(n => renderNode(n))}
            </div>
        </div>
    );
};


interface MenuProps {
    location: 'top' | 'bottom' | 'left' | 'right'
}

export default HirarchyButton;