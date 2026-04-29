function thousandSeparator(n: number): string {
    function rThousands(numString) {
        const rhs = numString.substring(numString.length - 3, numString.length);
        const lhs = numString.substring(0, numString.length - 3);

        if (lhs.length > 3) {
            return `${rThousands(lhs)}.${rhs}`;
        } else {
            return `${lhs ? lhs + '.' : ''}${rhs}`;
        }
    }

    return rThousands(String(n));
}
