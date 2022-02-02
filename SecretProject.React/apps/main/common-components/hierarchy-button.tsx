import HierarchyElement from "@/shared/models/hierarchy-element";
import classNames from "classnames";
import React, { Fragment, useState } from "react";
import { Button, ButtonProps, Dropdown } from "react-bootstrap";

interface HirarchyButtonProps extends ButtonProps {
    node: HierarchyElement;
    location: "top" | "bottom" | "left" | "right";
    locationToNext?: "top" | "bottom" | "left" | "right";
    applyActoinOnlyToEndChildren: boolean;
    showMenu?: boolean;

    actionToElement?: (id: string, parent: boolean) => void;
    setActiveNodeId?: (id: string) => void;
}

interface HierarchyButtonState {
    showMenu: boolean;
    currentActiveId: string;
}

const HirarchyButton: React.FC<HirarchyButtonProps> = (props) => {
    const {
        node,
        location,
        locationToNext,
        applyActoinOnlyToEndChildren,
        showMenu,

        actionToElement,
        setActiveNodeId,
    } = props;

    const nextMenuLocation = locationToNext ?? "left";

    const [state, setState] = useState<HierarchyButtonState>({
        showMenu: false,
        currentActiveId: "",
    });

    const toggleRootMenu = () => {
        setState({ ...state, showMenu: !state.showMenu });

        return (
            <div className={classNames({ hierarchy: node.IsRoot })}>
                <Button
                    variant="secondary"
                    className={classNames(
                        "hierarchy-item",
                        state.showMenu ? "location-" + location : ""
                    )}
                    onClick={toggleRootMenu}
                >
                    {node.Name}
                </Button>
                {state.showMenu && (
                    <>
                        <div className="show after-hierarchy-button" />
                        <div
                            className={classNames(
                                "hierarchy-menu node-menu pb-3 pt-3 show",
                                state.showMenu ? "location-" + location : ""
                            )}
                        >
                            {node.Children.map((n) => (
                                <HirarchyButton
                                    key={n.Id}
                                    node={n}
                                    location={location}
                                    actionToElement={actionToElement}
                                    showMenu={state.currentActiveId == n.Id}
                                    setActiveNodeId={() =>
                                        setState({
                                            ...state,
                                            currentActiveId: n.Id,
                                        })
                                    }
                                    active={
                                        props.node.Id == state.currentActiveId
                                    }
                                    applyActoinOnlyToEndChildren={
                                        applyActoinOnlyToEndChildren
                                    }
                                />
                            ))}
                        </div>
                    </>
                )}
            </div>
        );
    };

    return (
        <>
            <div
                className={classNames(
                    "hierarchy-item",
                    state.showMenu ? "location-" + nextMenuLocation : ""
                )}
            >
                <Button
                    variant="secondary"
                    onClick={() => setActiveNodeId && setActiveNodeId(node.Id)}
                >
                    {node.Name}
                </Button>
            </div>
            {showMenu && (
                <div
                    className={classNames(
                        "hierarchy-menu pb-3 pt-3 show",
                        state.showMenu ? "location-" + nextMenuLocation : ""
                    )}
                >
                    {node.Children.map((n) => (
                        <HirarchyButton
                            key={n.Id}
                            node={n}
                            location={location}
                            actionToElement={actionToElement}
                            showMenu={state.currentActiveId == n.Id}
                            setActiveNodeId={setActiveNodeId}
                            active={props.node.Id == state.currentActiveId}
                            applyActoinOnlyToEndChildren={
                                applyActoinOnlyToEndChildren
                            }
                        />
                    ))}
                </div>
            )}
        </>
    );
};

export default HirarchyButton;
