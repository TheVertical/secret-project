import React, { Children } from 'react';
import { Container, Row, Col } from 'bootstrap-4-react'
//Атомарные компоненты
import Block from './Block'
import ContactBlock from './ContactBlock'
import LinksMenu from './LinksMenu'
import Search from '../ComplexComponents/Search';
import ImageBlock from './ImageBlock'
import MiniProductCard from '../ComplexComponents/MiniProductCard'
import LinkButton from './LinkButton';
import { Button } from 'bootstrap-4-react';
import { NavLink } from 'react-router-dom';
import ComboBoxButton from './ComboBoxButton';
import { withRouter } from 'react-router-dom'

class VisualFactory extends React.Component {
    static renderVisualElement(element) {
        const TYPE = element.Type;
        switch (TYPE) {
            case "Block":
                return (
                    <div>
                        <Block Id={element.Id} VisualElements={element.VisualElements}></Block>
                    </div>
                );
                break;
            case "Search":
                return (
                    <div>
                        <Search Id={element.Id} VisualElements={element.VisualElements}></Search>
                    </div>
                );
                break;
            case "Label":
                return (
                    <p>{element.Text}</p>
                );
            case "MiniProductCard":
                return (
                    <div>
                        <MiniProductCard Price={element.Model.Price} Title={element.Model.Title} ImageUrl="./Images/Product.jpg"></MiniProductCard>
                    </div>
                );
                break;
                return (
                    <div>
                        <NavLink to={element.Action}>
                            <Button Id={element.Id}>{element.Title || element.Image}</Button>
                        </NavLink>
                    </div>
                );
            case "Button":
                return (
                    <LinkButton />
                );
            case "ComboBoxButton":
                return (
                    <div>
                        <ComboBoxButton
                            Id={element.Id}
                            Title={element.Title}
                            Image={element.Image}
                            Action={element.Action}
                            Dropdown={element.DropdownMenu}
                            Items={element.Items}
                            DropdownMenu={element.DropdownMenu}></ComboBoxButton>
                    </div>
                );
            case "ContactBlock":
                return (
                    <div>
                        <ContactBlock Id={element.Id} Phone={element.Phone} OpeningHours={element.OpeningHours} IsHeaderStyle={true}></ContactBlock>
                    </div>
                );
            case "LinksMenu":
                return (
                    <div>
                        <LinksMenu Id={element.Id} Links={element.Links} IsHorizontal={element.IsHorizontal} MainTitle={element.MainTitle} ></LinksMenu>
                    </div>
                );
            case "ImageBlock":
                return (
                    <div>
                        <ImageBlock Id={element.Id} Alt={element.Alt} Source={element.Source}  ></ImageBlock>
                    </div>
                );
                break;
            default:
                let error = "Uncorrect type " + element.Type + " was come!"
                throw error;
        }
    }
}
export default VisualFactory;
