import React, { Children } from 'react';
import { Container, Row, Col } from 'bootstrap-4-react'
//Атомарные компоненты
import Block from './Block'
import ContactBlock from './ContactBlock'
import LinksMenu from './LinksMenu'
import Search from '../ComplexComponents/Search';
import ProductCard from '../ComplexComponents/MiniProductCard';
import ImageBlock from './ImageBlock'
import MiniProductCard from '../ComplexComponents/MiniProductCard'
import Header from '../hoc/LayoutElements/Header'
import Footer from '../hoc/LayoutElements/Header'
import LinkList from '../ComplexComponents/LinkList'
import ContactSectionFoot from '../ComplexComponents/ContactSectionFoot'
import ContactSectionHeader from '../ComplexComponents/ContactSectionHeader'
import DropdownMenu from './DropdownMenu'

import { Button } from 'react-bootstrap';

class VisualElement extends React.Component {
    static renderVisualElement(element) {
        const TYPE = element.Type;

        switch (TYPE) {
            //Компонент типа ComplexComponents - Вызывает рекурсию



            case "Block":
                return (
                    //Возвращает компонент Секция контактов (для футера)
                    <div>
                        <Block Id={element.Id} VisualElements={element.VisualElements}></Block>
                    </div>
                );
                break;


            //Компонент типа ComplexComponents - Вызывает рекурсию
            case "Search":
                return (
                    //Возвращает компонент ComboBoxButton
                    <div>
                        <Search Id={element.Id} VisualElements={element.VisualElements}></Search>
                    </div>
                );
                break;

            //Компонент типа ComplexComponents - Вызывает рекурсию
            case "MiniProductCard":
                return (
                    //Возвращает компонент ImageBlock
                    <div>
                        <MiniProductCard Price={element.Model.Price} Title={element.Model.Title} ImageUrl="./Images/Product.jpg"></MiniProductCard>
                    </div>
                );
                break;
            //Компонент типа BasedComponents
            case "Button":
                return (
                    <div>
                        <Button Id={element.Id} href={element.Action}>{element.Title || element.Image}</Button>
                    </div>
                );
            case "ComboBoxButton":
                return (
                    <div>
                        <DropdownMenu Id={element.Id} Dropdown={element.DropdownMenu} Items={element}></DropdownMenu>
                    </div>
                );
            //Компонент типа BasedComponents
            case "ContactBlock":
                return (
                    <div>
                        <ContactBlock Id={element.Id} Phone={element.Phone} OpeningHours={element.OpeningHours} IsHeaderStyle={true}></ContactBlock>
                    </div>
                );
            //Компонент типа BasedComponents
            case "LinksMenu":
                return (
                    //Возвращает компонент DropdownMenu
                    <div>
                        <LinksMenu Id={element.Id} Links={element.Links}></LinksMenu>
                    </div>
                );
            //Компонент типа BasedComponents
            case "ImageBlock":
                return (
                    //Возвращает компонент DropdownMenu
                    <div>
                        <ImageBlock Id={element.Id} Links={element.Links} src={element.Source}></ImageBlock>
                    </div>
                );

        }

    }
}
export default VisualElement;
