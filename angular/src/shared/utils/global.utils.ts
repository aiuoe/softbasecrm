export const nextGuid = () => {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }

    return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
};

export const objectToArray = (obj: object) => {
    return Object.keys(obj)
        .filter((x) => isNaN(Number(x)))
        .map((key) => ({
            text: key,
            value: obj[key],
        }));
};
