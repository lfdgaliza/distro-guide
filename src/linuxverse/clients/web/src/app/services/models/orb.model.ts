import { Orbiter } from './orbiter.model';

export abstract class Orb
{
    protected _size: number
    protected _depth: number

    private _id: string
    private _name: string
    private _children: Array<Orbiter>

    constructor(id: string, name: string)
    {
        this._id = id
        this._name = name
        this._children = new Array<Orbiter>()
    }

    public get name(): string
    {
        return this._name
    }

    public get size(): number
    {
        return this._size
    }

    public get children(): Array<Orbiter>
    {
        return this._children
    }

    public addChild(newChild: Orbiter): void
    {
        newChild.parent = this
        newChild.refreshSize()
        this.children.push(newChild)
    }
}