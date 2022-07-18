import { render, screen } from '@testing-library/react';
import  HomePage  from "./home.page"


test('HomePage should have a title of ,,Termékeink listája,,', async ()=>
{
    render(<HomePage />);
    const cardTitleText: HTMLElement = screen.getByText("Termékeink listája");
    expect(cardTitleText).toBeInTheDocument;
});