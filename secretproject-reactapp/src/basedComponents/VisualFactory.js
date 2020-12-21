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
                    <Block Id={element.Id} VisualElements={element.VisualElements}></Block>
                );
                break;
            case "VisualSearch":
                return (
                    <Search Id={element.Id} VisualElements={element.VisualElements}></Search>
                );
                break;
            case "Label":
                return (
                    <p>{element.Text}</p>
                );
            case "MiniProductCard":
                return (
                    <MiniProductCard Price={element.Model.Price} Title={element.Model.Title} ImageUrl="./Images/Product.jpg"></MiniProductCard>
                );
                break;
                return (
                    <NavLink to={element.Action}>
                        <Button Id={element.Id}>{element.Title || element.Image}</Button>
                    </NavLink>
                );
            case "Button":
                return (
                    <LinkButton Id={element.Id} Title={element.Title} Image={element.Image} Action={element.Action} />
                );
            case "ComboBoxButton":
                return (
                    <ComboBoxButton
                        Id={element.Id}
                        Title={element.Title}
                        Image={element.Image}
                        Action={element.Action}
                        Dropdown={element.DropdownMenu}
                        Items={element.Items}
                        DropdownMenu={element.DropdownMenu}></ComboBoxButton>
                );
            case "ContactBlock":
                return (
                    <ContactBlock Id={element.Id} Phone={element.Phone} OpeningHours={element.OpeningHours} IsHeaderStyle={true}></ContactBlock>
                );
            case "LinksMenu":
                return (
                    <LinksMenu Id={element.Id} Links={element.Links} IsHorizontal={element.IsHorizontal} MainTitle={element.MainTitle} ></LinksMenu>
                );
            case "ImageBlock":
                return (
                    <ImageBlock Id={element.Id} Alt={element.Alt} Source={element.Source}  ></ImageBlock>
                );
                break;
            default:
                let error = "Uncorrect type " + element.Type + " was come!"
                throw error;
        }
    }
}
export default VisualFactory;
