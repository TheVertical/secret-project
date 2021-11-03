const CurencyService = {
    toRubles(number: number): string {
        var n = String(number);
        n = n.replace(/(\d{1,3}(?=(?:\d\d\d)+(?!\d)))/g, "$1" + ' ');
        return n + ' ₽';
    }
}

export default CurencyService;