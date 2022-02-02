export default interface HierarchyElement {
    Id: string,
    Name: string,
    IsRoot: boolean,
    Parent?: HierarchyElement,
    Children: HierarchyElement[]
}