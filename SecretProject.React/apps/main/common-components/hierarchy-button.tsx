import HierarchyElement from '@/shared/models/HierarchyElement';
import React from 'react';
import { Button, Dropdown } from 'react-bootstrap';

interface HirarchyButtonProps {
    root: HierarchyElement,
    actionToElement: (id: string, parent: boolean) => void,
    applyActoinOnlyToEndChildren: boolean
};

const HirarchyButton: React.FC<HirarchyButtonProps> = (props) => {
    const {
        root,
        actionToElement,
        applyActoinOnlyToEndChildren } = props;

    const renderNode = function (node: HierarchyElement): any {
        if (node.Children.length == 0) {
            return <Button onClick={() => actionToElement(node.Id, false)}>{node.Name}</Button>
        }

        return (
            <Dropdown>
                <Dropdown.Toggle variant="primary" id={node.Id}>
                    {node.Name}
                </Dropdown.Toggle>

                <Dropdown.Menu>
                    {node.Children.map(c => renderNode(c))}
                </Dropdown.Menu>
            </Dropdown>
        );
    };

return (renderNode(root));
}

export default HirarchyButton;