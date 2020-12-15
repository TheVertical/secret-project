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
import DropdownMenu from './DropdownMenu'

import { Button } from 'bootstrap-4-react';
import { NavLink } from 'react-router-dom';

class VisualFactory extends React.Component {
    static renderVisualElement(element) {
        console.log(element);
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
                        <NavLink to={element.Action}>
                        <Button Id={element.Id}>{element.Title || element.Image}</Button>
                        </NavLink>
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
                        <LinksMenu Id={element.Id} Links={element.Links} IsHorizontal={element.IsHorizontal} MainTitle={element.MainTitle}></LinksMenu>
                    </div>
                );
            //Компонент типа BasedComponents
            case "ImageBlock":
                return (
                    //Возвращает компонент DropdownMenu
                    <div>
                        <ImageBlock Id={element.Id} Alt={element.Alt} Source={element.Source}></ImageBlock>
                    </div>
                );

        }

    }
}
export default VisualFactory;
