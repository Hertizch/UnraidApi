using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models
{
    public class ApcUpsd
    {
        /// <summary>
        /// Date and time of last update from UPS
        /// </summary>
        [J("DATE")] public string DATE { get; set; }

        /// <summary>
        /// hostname of computer running apcupsd
        /// </summary>
        [J("HOSTNAME")] public string HOSTNAME { get; set; }

        /// <summary>
        /// apcupsd version number, date and operating system
        /// </summary>
        [J("VERSION")] public string VERSION { get; set; }

        /// <summary>
        /// UPS name from configuration file (dumb) or EEPROM (smart)
        /// </summary>
        [J("UPSNAME")] public string UPSNAME { get; set; }

        /// <summary>
        /// Cable type specified in the configuration file
        /// </summary>
        [J("CABLE")] public string CABLE { get; set; }

        /// <summary>
        /// UPS model derived from UPS information
        /// </summary>
        [J("MODEL")] public string MODEL { get; set; }

        /// <summary>
        /// Mode in which UPS is operating
        /// </summary>
        [J("UPSMODE")] public string UPSMODE { get; set; }

        /// <summary>
        /// Date and time apcupsd was started
        /// </summary>
        [J("STARTTIME")] public string STARTTIME { get; set; }

        /// <summary>
        /// UPS status (online, charging, on battery etc)
        /// </summary>
        [J("STATUS")] public string STATUS { get; set; }

        /// <summary>
        /// Last time the master sent an update to the slave
        /// </summary>
        [J("MASTERUPD")] public string MASTERUPD { get; set; }

        /// <summary>
        /// Date and time of status information was written
        /// </summary>
        [J("ENDAPC")] public string ENDAPC { get; set; }

        /// <summary>
        /// Current input line voltage
        /// </summary>
        [J("LINEV")] public string LINEV { get; set; }

        /// <summary>
        /// Percentage of UPS load capacity used as estimated by UPS
        /// </summary>
        [J("LOADPCT")] public string LOADPCT { get; set; }

        /// <summary>
        /// Current battery capacity charge percentage
        /// </summary>
        [J("BCHARGE")] public string BCHARGE { get; set; }

        /// <summary>
        /// Remaining runtime left on battery as estimated by the UPS
        /// </summary>
        [J("TIMELEFT")] public string TIMELEFT { get; set; }

        /// <summary>
        /// Min battery charge % (BCHARGE) required for system shutdown
        /// </summary>
        [J("MBATTCHG")] public string MBATTCHG { get; set; }

        /// <summary>
        /// Min battery runtime (MINUTES) required for system shutdown
        /// </summary>
        [J("MINTIMEL")] public string MINTIMEL { get; set; }

        /// <summary>
        /// Max battery runtime (TIMEOUT) after which system is shutdown
        /// </summary>
        [J("MAXTIME")] public string MAXTIME { get; set; }

        /// <summary>
        /// Maximum input line voltage since apcupsd started
        /// </summary>
        [J("MAXLINEV")] public string MAXLINEV { get; set; }

        /// <summary>
        /// Min (observed) input line voltage since apcupsd started
        /// </summary>
        [J("MINLINEV")] public string MINLINEV { get; set; }

        /// <summary>
        /// Current UPS output voltage
        /// </summary>
        [J("OUTPUTV")] public string OUTPUTV { get; set; }

        /// <summary>
        /// Current UPS sensitivity setting for voltage fluctuations
        /// </summary>
        [J("SENSE")] public string SENSE { get; set; }

        /// <summary>
        /// Time UPS waits after power off when the power is restored
        /// </summary>
        [J("DWAKE")] public string DWAKE { get; set; }

        /// <summary>
        /// Delay before UPS powers down after command received
        /// </summary>
        [J("DSHUTD")] public string DSHUTD { get; set; }

        /// <summary>
        /// Low battery signal sent when this much runtime remains
        /// </summary>
        [J("DLOWBATT")] public string DLOWBATT { get; set; }

        /// <summary>
        /// Input line voltage below which UPS will switch to battery
        /// </summary>
        [J("LOTRANS")] public string LOTRANS { get; set; }

        /// <summary>
        /// Input line voltage above which UPS will switch to battery
        /// </summary>
        [J("HITRANS")] public string HITRANS { get; set; }

        /// <summary>
        /// Battery charge % required after power off to restore power
        /// </summary>
        [J("RETPCT")] public string RETPCT { get; set; }

        /// <summary>
        /// UPS internal temperature in degrees Celcius
        /// </summary>
        [J("ITEMP")] public string ITEMP { get; set; }

        /// <summary>
        /// Delay period before UPS starts sounding alarm
        /// </summary>
        [J("ALARMDEL")] public string ALARMDEL { get; set; }

        /// <summary>
        /// Current battery voltage
        /// </summary>
        [J("BATTV")] public string BATTV { get; set; }

        /// <summary>
        /// Current line frequency in Hertz
        /// </summary>
        [J("LINEFREQ")] public string LINEFREQ { get; set; }

        /// <summary>
        /// Reason for last transfer to battery since apcupsd startup
        /// </summary>
        [J("LASTXFER")] public string LASTXFER { get; set; }

        /// <summary>
        /// Number of transfers to battery since apcupsd startup
        /// </summary>
        [J("NUMXFERS")] public string NUMXFERS { get; set; }

        /// <summary>
        /// Date, time of last transfer to battery since apcupsd startup
        /// </summary>
        [J("XONBATT")] public string XONBATT { get; set; }

        /// <summary>
        /// Seconds currently on battery
        /// </summary>
        [J("TONBATT")] public string TONBATT { get; set; }

        /// <summary>
        /// Cumulative seconds on battery since apcupsd startup
        /// </summary>
        [J("CUMONBATT")] public string CUMONBATT { get; set; }

        /// <summary>
        /// Date, time of last transfer off battery since apcupsd startup
        /// </summary>
        [J("XOFFBAT")] public string XOFFBAT { get; set; }

        /// <summary>
        /// Date and time of last self test since apcupsd startup
        /// </summary>
        [J("SELFTEST")] public string SELFTEST { get; set; }

        /// <summary>
        /// Self-test interval
        /// </summary>
        [J("STESTI")] public string STESTI { get; set; }

        /// <summary>
        /// UPS status flag in hex
        /// </summary>
        [J("STATFLAG")] public string STATFLAG { get; set; }

        /// <summary>
        /// Current UPS DIP switch settings
        /// </summary>
        [J("DIPSW")] public string DIPSW { get; set; }

        /// <summary>
        /// Fault register 1 in hex
        /// </summary>
        [J("REG1")] public string REG1 { get; set; }

        /// <summary>
        /// Fault register 2 in hex
        /// </summary>
        [J("REG2")] public string REG2 { get; set; }

        /// <summary>
        /// Fault register 3 in hex
        /// </summary>
        [J("REG3")] public string REG3 { get; set; }

        /// <summary>
        /// UPS date of manufacture
        /// </summary>
        [J("MANDATE")] public string MANDATE { get; set; }

        /// <summary>
        /// UPS serial number
        /// </summary>
        [J("SERIALNO")] public string SERIALNO { get; set; }

        /// <summary>
        /// Date battery last replaced(if set)
        /// </summary>
        [J("BATTDATE")] public string BATTDATE { get; set; }

        /// <summary>
        /// Nominal output voltage to supply when on battery power
        /// </summary>
        [J("NOMOUTV")] public string NOMOUTV { get; set; }

        /// <summary>
        /// Nominal battery voltage
        /// </summary>
        [J("NOMBATTV")] public string NOMBATTV { get; set; }

        /// <summary>
        /// Number of external batteries(for XL models)
        /// </summary>
        [J("EXTBATTS")] public string EXTBATTS { get; set; }

        /// <summary>
        /// Number of bad external battery packs(for XL models)
        /// </summary>
        [J("BADBATTS")] public string BADBATTS { get; set; }

        /// <summary>
        /// UPS firmware version
        /// </summary>
        [J("FIRMWARE")] public string FIRMWARE { get; set; }

        /// <summary>
        /// APC model information
        /// </summary>
        [J("APCMODEL")] public string APCMODEL { get; set; }

        /// <summary>
        /// Date, time of last transfer off battery since apcupsd startup
        /// </summary>
        [J("XOFFBATT")] public string XOFFBATT { get; set; }

        /// <summary>
        /// Ambient humidity
        /// </summary>
        [J("HUMIDITY")] public string HUMIDITY { get; set; }

        /// <summary>
        /// Ambient temperature
        /// </summary>
        [J("AMBTEMP")] public string AMBTEMP { get; set; }

        /// <summary>
        /// Nominal input voltage
        /// </summary>
        [J("NOMINV")] public string NOMINV { get; set; }
    }
}
