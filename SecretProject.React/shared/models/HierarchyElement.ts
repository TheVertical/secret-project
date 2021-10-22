export default interface HierarchyElement {
    Id: string,
    Name: string,
    IsRoot: boolean,
    Children: HierarchyElement[]
}